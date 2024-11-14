# The “server” peer sends a list of available files to the centralized server.
# Then it accepts clients. When a client is connected:
# it reads a filename from the client
# then sends the file to the client (see hints for sending files)

# The server peer has 3 functions.
# Registering a list of files to the centralized server (consuming REST) when it starts
# Listening for TCP connections, when one connects, reads the first line in the format:
#  GET <filename>
# Then sends back the requested file
# (Optional) Deregistering the list of files on the centralized server (consuming REST) when it stops
# Look at the hints for a clue about listing files.

import threading
from socket import AF_INET, SOCK_STREAM, socket

SERVER_PORT = 12000
BUFFER_SIZE = 1024
CLOSING_MESSAGE = "Closing connection."

# Main program flow
def main():
    serverSocket = socket(AF_INET, SOCK_STREAM)
    serverSocket.bind(("", SERVER_PORT))
    serverSocket.listen(1)

    print("Server is ready to listen")

    RegisterFiles()

    while True:
        connectionSocket, addr = serverSocket.accept()
        threading.Thread(
            target=handleClient, args=(connectionSocket, addr)).start()  # Concurrency - more threads / connection
        # handleClient(connectionSocket, addr) # Sequential - 1 thread / connection


# Function definitions
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


def RegisterFiles():
    print("Files registered")

# Entry point
if __name__ == "__main__":
    main()