import random
from socket import AF_INET, SO_BROADCAST, SOCK_DGRAM, SOL_SOCKET, socket
from time import sleep

SERVER_NAME = "255.255.255.255"
SERVER_PORT = 12000
clientSocket = socket(AF_INET, SOCK_DGRAM)
clientSocket.setsockopt(SOL_SOCKET, SO_BROADCAST, 1)

MIN_SPEED = 20
MAX_SPEED = 150
MIN_RANDOM_TIME = 1
MAX_RANDOM_TIME = 5
TOWNS = ["Albertslund", "Ballerup", "Charlottenlund", "Dragør", "Espergærde"]

while True:
    interval = random.randint(MIN_RANDOM_TIME, MAX_RANDOM_TIME)
    random_town = random.choice(TOWNS)
    random_speed = random.randint(MIN_SPEED, MAX_SPEED)

    sleep(interval)

    sensor_data = f'{{"SensorName":"{random_town} speedtrap","Speed":{random_speed}}}'
    print(f"broadcasting: {sensor_data}")
    clientSocket.sendto(sensor_data.encode(), (SERVER_NAME, SERVER_PORT))
    # modifiedMessage, serverAddress = clientSocket.recvfrom(2048)
    # print((modifiedMessage.decode()))
    # clientSocket.close()