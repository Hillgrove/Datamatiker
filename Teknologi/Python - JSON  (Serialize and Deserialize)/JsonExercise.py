import json

person = {
    "Id": 1,
    "Name": "John Due",
    "Age": 33,
    "Description": "Incognito",
}


# One way of printing out each value
for value in person:
    print(person[value])

print()


# Second way of printing out each value
for value in person.values():
    print(value)


# JSON serialization
serializedDict = json.dumps(person)

print()

manualSerialized = (
    '{"Id": 1, "Name": "John Due", "Age": 33, "Description": "Incognito"}'
)

print(manualSerialized)
print(serializedDict)

print()


# JSON Deserialization
new_person = json.loads(serializedDict)

for value in new_person.values():
    print(value)

print()


# Extra: Escaping special characters
testString = '{"name": "tes\\"t\\"name","age":2}'
testDict = json.loads(testString)

print(testDict)
print()


# Extra: Working with others Json
foreignJSON = '{"Name":"Move Cars","Address":"MagleGaardsvej 2","Cars":[{"Brand":"BMW","Model":"330e","Color":"Green","Mileage":45721},{"Brand":"VW","Model":"Golf","Color":"Red","Mileage":20},{"Brand":"Ford","Model":"Galaxy","Color":"Black","Mileage":124326}],"Employees":[{"Name":"Move","Salary":1000000,"MonthsEmployed":28,"JobAreas":["President","Mechanic"]},{"Name":"Not Move","Salary":100,"MonthsEmployed":13,"JobAreas":["Vice-President","Mechanic"]}]}'

foreignDict = json.loads(foreignJSON)

cars = foreignDict["Cars"]
print(cars)
second_car = cars[1]
print(second_car)
color = second_car["Color"]
print(color)

second_car_color = foreignDict["Cars"][1]["Color"]
print(second_car_color)