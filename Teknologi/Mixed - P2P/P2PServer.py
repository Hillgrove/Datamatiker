import threading
from socket import AF_INET, SOCK_STREAM, socket

import requests

REST_SERVER_IP = "localhost"
REST_SERVER_PORT = 5123

SERVER_PEER_IP = "127.0.0.1"
SERVER_PEER_PORT = 6000

MAX_CONNECTIONS = 5
BUFFER_SIZE = 4096

filenames = ["file1.txt", "file2.txt", "file3.txt"]


def register_file(filename, file_endpoint):
    url = f"http://{REST_SERVER_IP}:{REST_SERVER_PORT}/api/FileEndPoints/{filename}"

    try:
        response = requests.post(url, json=file_endpoint)
        if response.status_code == 201:
            print(f'Registered file "{filename}" successfully.')
        else:
            print(
                f'Failed to register file "{filename}": {response.status_code} {response.text}'
            )

    except requests.exceptions.RequestException as e:
        print(f"Error connecting to REST server: {e}")


def handle_client(client_socket, addr):
    try:
        # Receive the request from the client
        request_line = client_socket.recv(BUFFER_SIZE).decode().strip()
        print(f"[{addr}] Received request: {request_line}")

        if request_line.startswith("GET "):
            filename = request_line[4:].strip()

            if filename in filenames:
                # Send back the filename
                client_socket.sendall(filename.encode())
                print(f'[{addr}] Sent filename "{filename}" to client.')
            else:
                error_msg = f'File "{filename}" is not shared by this server.'
                client_socket.sendall(error_msg.encode())
                print(f"[{addr}] {error_msg}")
        else:
            error_msg = 'Invalid request format. Expected "GET <filename>".'
            client_socket.sendall(error_msg.encode())
            print(f"[{addr}] {error_msg}")

    except Exception as e:
        print(f"[{addr}] Error handling client: {e}")

    finally:
        client_socket.close()


def start_server():
    server = socket(AF_INET, SOCK_STREAM)
    server.bind((SERVER_PEER_IP, SERVER_PEER_PORT))
    server.listen(MAX_CONNECTIONS)
    print(f"Server is listening on {SERVER_PEER_IP}:{SERVER_PEER_PORT}")
    try:
        while True:
            client_socket, addr = server.accept()
            print(f"Accepted connection from {addr}")
            client_thread = threading.Thread(
                target=handle_client, args=(client_socket, addr)
            )
            client_thread.start()
    except KeyboardInterrupt:
        print("Server is shutting down.")
    finally:
        server.close()


def main():
    file_endpoint = {"IPAddress": SERVER_PEER_IP, "Port": SERVER_PEER_PORT}

    # Register each file with the centralized REST server
    for filename in filenames:
        register_file(filename, file_endpoint)

    # Start the server to listen for incoming client connections
    start_server()


if __name__ == "__main__":
    main()
