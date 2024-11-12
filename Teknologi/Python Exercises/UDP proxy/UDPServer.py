from socket import AF_INET, SOCK_DGRAM, socket

serverPort = 12000
serverSocket = socket(AF_INET, SOCK_DGRAM)

serverAddress = ("", serverPort)

serverSocket.bind(serverAddress)
print("The server is ready")
while True:
    message, clientAddress = serverSocket.recvfrom(2048)
    print("Received message:" + message.decode())
    modifiedMessage = message.decode().upper()
    serverSocket.sendto(modifiedMessage.encode(), clientAddress)
