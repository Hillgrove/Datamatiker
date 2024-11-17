import ssl
from socket import AF_INET, SOCK_STREAM, socket

SERVER_NAME = "localhost"
SERVER_PORT = 12000
CLOSING_MESSAGE = "Closing connection."

context = ssl.SSLContext(ssl.PROTOCOL_TLSv1_2)

client_socket = socket(AF_INET, SOCK_STREAM)
client_socket.connect((SERVER_NAME, SERVER_PORT))

secure_socket = context.wrap_socket(client_socket)

while True:
    sentence = input("Input sentence: ")

    if sentence == "exit":
        print(CLOSING_MESSAGE)
        secure_socket.close()
        break

    secure_socket.send(sentence.encode())
    modified_sentence = secure_socket.recv(1024)
    print("From server: ", modified_sentence.decode())
