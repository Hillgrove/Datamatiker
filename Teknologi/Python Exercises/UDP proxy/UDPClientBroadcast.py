from socket import AF_INET, SO_BROADCAST, SOCK_DGRAM, SOL_SOCKET, socket

serverName = '255.255.255.255'
serverPort = 12000
clientSocket = socket(AF_INET, SOCK_DGRAM)
clientSocket.setsockopt(SOL_SOCKET, SO_BROADCAST, 1)

message = input('Input message:')
clientSocket.sendto(message.encode(), (serverName, serverPort))
modifiedMessage, serverAddress = clientSocket.recvfrom(2048)
print((modifiedMessage.decode()))
clientSocket.close()
