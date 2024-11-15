import requests
import socket

# Constants
REST_SERVER_IP = "localhost"
REST_SERVER_PORT = 5123
FILE_API_ROUTE = "api/FileEndPoints"
BUFFER_SIZE = 1024

api_url = f"http://{REST_SERVER_IP}:{REST_SERVER_PORT}/{FILE_API_ROUTE}"


def get_available_files():
    """Fetch the list of available files from the REST server."""
    try:
        response = requests.get(api_url)
        response.raise_for_status()
        return response.json()
    except requests.exceptions.RequestException as e:
        print(f"Error fetching file list: {e}")
        return []


def get_file_details(filename):
    """Fetch details of the selected file from the REST server."""
    try:
        response = requests.get(f"{api_url}/{filename}")
        response.raise_for_status()
        return response.json()
    except requests.exceptions.RequestException as e:
        print(f"Error fetching file details for {filename}: {e}")
        return []


def display_files(files):
    """Display the list of available files to the user."""
    print("Available files:")
    for index, filename in enumerate(files, start=1):
        print(f"{index}. {filename}")


def select_file(files):
    """Prompt the user to select a file from the available files."""
    try:
        selected_index = int(input("Select a file by number: ")) - 1
        if 0 <= selected_index < len(files):
            return files[selected_index]
        else:
            print("Invalid selection. Please try again.")
            return select_file(files)
    except ValueError:
        print("Invalid input. Please enter a number.")
        return select_file(files)


def connect_to_peer_server(ip, port, filename):
    """Connect to the peer server and request the selected file."""
    try:
        my_socket = socket.socket()
        my_socket.connect((ip, port))
        request = f"GET {filename}"
        my_socket.send(request.encode())
        return my_socket
    except Exception as e:
        print(f"Error connecting to peer server: {e}")
        return None


def receive_file_data(my_socket):
    """Receive the file data from the peer server."""
    received_data = b""
    while True:
        file_data = my_socket.recv(BUFFER_SIZE)
        if not file_data:
            break
        received_data += file_data
    return received_data


def main():
    files = get_available_files()
    if not files:
        return

    display_files(files)
    filename = select_file(files)
    print(f"Selected file: {filename}")

    file_details = get_file_details(filename)
    if not file_details:
        return

    server_ip = file_details[0]["ipAddress"]
    server_port = file_details[0]["port"]

    print(f"Connecting to peer server at {server_ip}:{server_port}...")

    my_socket = connect_to_peer_server(server_ip, server_port, filename)
    if not my_socket:
        return

    print(f"Receiving file from {server_ip}:{server_port}...")

    received_data = receive_file_data(my_socket)
    print(f"Received data:\n{received_data.decode()}")

    my_socket.close()
    print("File transfer simulation complete.")


if __name__ == "__main__":
    main()