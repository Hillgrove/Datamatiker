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

serverSocket = socket(AF_INET, SOCK_STREAM)
serverSocket.bind(("", SERVER_PORT))
serverSocket.listen(1)
secureSocket = context.wrap_socket(serverSocket, server_side=True)

print("Server is ready to listen")


def handleClient(connectionSocket, address):
    connectionOpen = True
    while connectionOpen:
        sentence = connectionSocket.recv(BUFFER_SIZE).decode()

        if sentence == "exit\r\n":
            connectionSocket.send(CLOSING_MESSAGE.encode())
            connectionSocket.close()
            connectionOpen = False
            break

        print(sentence)
        capitalizedSentence = sentence.upper()
        connectionSocket.send(capitalizedSentence.encode())


while True:
    connectionSocket, addr = secureSocket.accept()
    threading.Thread(
        target=handleClient, args=(connectionSocket, addr)
    ).start()  # Concurrency - more threads / connection
    # handleClient(connectionSocket, addr) # Sequential - 1 thread / connection
