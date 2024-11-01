import requests

BASEURL = "https://hill-pokemonapi.azurewebsites.net/api/pokemons"

response = requests.get(BASEURL)
pokemons = response.json()


# Print whole array
print("The whole array of pokemons:")
print(pokemons)


# Print a single pokemon
print("\nA single pokemon using indexing:")
index = 4
print(pokemons[index]) # or

id = 5
response = requests.get(f"{BASEURL}/{id}")
single_pokemon = response.json()
print("\nA single pokemon using /<id>")
print(single_pokemon)

# Creating a new pokemon
new_pokemon = {"name": "Klump", "level": 3}
response = requests.post(BASEURL, json=new_pokemon)
created_pokemon = response.json()
print("\nNewly created pokemon:")
print(created_pokemon)

# Updating a pokemon with new values
new_data = {"name": "Thema", "level": 26}
id = 5 # redundant due to previously declared, but improves readability
response = requests.put(f"{BASEURL}/{id}", json=new_data)
updated_pokemon = response.json()
print("\nUpdated pokemon:")
print(updated_pokemon)

# Deleting a pokemon
id = requests.get(BASEURL).json()[-1]["id"] # Ugly one liner as I was lazy
response = requests.delete(f"{BASEURL}/{id}")
deleted_pokemon = response.json()
print("\nDelete the last pokemon in the list:")
print(deleted_pokemon)


