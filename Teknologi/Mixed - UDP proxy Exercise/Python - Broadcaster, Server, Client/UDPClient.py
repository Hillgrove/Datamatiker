
# Not used in this PROXY solution - but an example of a simple udp client

from socket import AF_INET, SOCK_DGRAM, socket

serverName = "localhost"
serverPort = 12000
clientSocket = socket(AF_INET, SOCK_DGRAM)

message = input("Input message:")
clientSocket.sendto(message.encode(), (serverName, serverPort))
modifiedMessage, serverAddress = clientSocket.recvfrom(2048)
print((modifiedMessage.decode()))
clientSocket.close()
