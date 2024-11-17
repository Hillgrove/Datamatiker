import threading
from socket import AF_INET, SOCK_STREAM, socket

SERVER_PORT = 12000
BUFFER_SIZE = 1024
CLOSING_MESSAGE = "Closing connection."

serverSocket = socket(AF_INET, SOCK_STREAM)
serverSocket.bind(("", SERVER_PORT))
serverSocket.listen(1)

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
    connectionSocket, addr = serverSocket.accept()
    threading.Thread(
        target=handleClient, args=(connectionSocket, addr)
    ).start()  # Concurrency - more threads / connection
    # handleClient(connectionSocket, addr) # Sequential - 1 thread / connection