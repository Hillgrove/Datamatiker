import ssl
import threading
from socket import AF_INET, SOCK_STREAM, socket

CERTIFICATES_DIRECTORY = "C:/Certificates/"
PRIVATE_KEY_PATH = CERTIFICATES_DIRECTORY + "key.pem"
CERTIFICATE_PATH = CERTIFICATES_DIRECTORY + "certificate.pem"
PRIVATE_KEY_PASSWORD = "notmypassword"

SERVER_PORT = 12000
BUFFER_SIZE = 1024
CLOSING_MESSAGE = "Closing connection."

context = ssl.SSLContext(ssl.PROTOCOL_TLS_SERVER)
context.load_cert_chain(
    certfile=CERTIFICATE_PATH,
    keyfile=PRIVATE_KEY_PATH,
    password=PRIVATE_KEY_PASSWORD,
)

server_socket = socket(AF_INET, SOCK_STREAM)
server_socket.bind(("", SERVER_PORT))
server_socket.listen(1)
secure_socket = context.wrap_socket(server_socket, server_side=True)

print("Server is ready to listen")


def handle_client(connection_socket, address):
    connection_open = True
    while connection_open:
        sentence = connection_socket.recv(BUFFER_SIZE).decode()

        if sentence == "exit\r\n":
            connection_socket.send(CLOSING_MESSAGE.encode())
            connection_socket.close()
            connection_open = False
            break

        print(sentence)
        capitalized_sentence = sentence.upper()
        connection_socket.send(capitalized_sentence.encode())


while True:
    connection_socket, addr = secure_socket.accept()
    threading.Thread(
        target=handle_client, args=(connection_socket, addr)
    ).start()  # Concurrency - more threads / connection
    # handle_client(connection_socket, addr) # Sequential - 1 thread / connection
