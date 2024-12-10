var baseUrl = 'https://localhost:7139';

// Function to create a new character
async function createCharacter(character) {
    console.log('Creating character:', character);
    const response = await fetch(`${baseUrl}/api/character`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(character)
    });
    console.log('Response:', response);
    if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
    }
    return await response.json();
}

// Function to delete a character by ID
async function deleteCharacter(id) {
    console.log('Deleting character with id:', id);
    const response = await fetch(`${baseUrl}/api/character/${id}`, {
        method: 'DELETE'
    });
    console.log('Response:', response);
    if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
    }
    return await response.json();
}

// Function to fetch all characters
async function getAllCharacters() {
    console.log('Fetching all characters');
    const response = await fetch(`${baseUrl}/api/character`);
    console.log('Response:', response);
    if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
    }
    return await response.json();
}

// Function to fetch a character by ID
async function getCharacterById(id) {
    console.log('Fetching character with id:', id);
    const response = await fetch(`${baseUrl}/api/character/${id}`);
    console.log('Response:', response);
    if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
    }
    return await response.json();
}

// Function to update an existing character
async function updateCharacter(character) {
    console.log('Updating character:', character);
    const response = await fetch(`${baseUrl}/api/character`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(character)
    });
    console.log('Response:', response);
    if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
    }
    return await response.json();
}
