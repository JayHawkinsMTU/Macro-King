import requests 
import json
# "C:\Python312\python.exe"
# Your API key
api_key = 'kt3fDVCgfMw7LSQfAdxF898dDjuQhsj4q2Q1eiXM'

# Base URL for FoodData Central API
base_url = 'https://api.nal.usda.gov/fdc/v1/foods/search'

# Parameters for the request (example: searching for "apple")
params = {
    'query': 'apple',  # Replace with your search query
    'pageSize': 10,  # Number of results per page
    'api_key': api_key  # Your API key
}

# Make the request
response = requests.get(base_url, params=params)

# Check if the request was successful
if response.status_code == 200:
    data:dict = response.json()  # Parse the response JSON
    #print(data)
        # Save the data to a file
    with open('API_CALL.json', 'w') as fp:
        json.dump(data, fp, indent=4)  # Pretty printing with an indent of 4 spaces
    print(data.keys())
    for a in data['foods']:
        print(a['description'])
        
    
else:

    print(f"Error: {response.status_code} - {response.text}")
