from socket import socket, AF_INET, SOCK_STREAM

SERVER_NAME = "localhost"
SERVER_PORT = 12000
CLOSING_MESSAGE = "Closing connection."

clientSocket = socket(AF_INET, SOCK_STREAM)
clientSocket.connect((SERVER_NAME, SERVER_PORT))

while True:
    sentence = input("Input sentence: ")

    if sentence == "exit":
        print(CLOSING_MESSAGE)
        clientSocket.close()
        break

    clientSocket.send(sentence.encode())
    modifiedSentence = clientSocket.recv(1024)
    print("From server: ", modifiedSentence.decode())
