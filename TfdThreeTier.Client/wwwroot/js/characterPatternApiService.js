var baseUrl = 'https://localhost:7139';

async function createCharacterPattern(characterPattern) {
    const response = await fetch(`${baseUrl}/api/characterPattern`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(characterPattern)
    });
    if (!response.ok) {
        const errorResponse = await response.text();
        console.error('Error response:', errorResponse);
        throw new Error(`HTTP error! status: ${response.status}, message: ${errorResponse}`);
    }
}

async function getCharacterPatternsByCharacterId(characterId) {
    console.log('Fetching character patterns for character with id:', characterId);
    const response = await fetch(`${baseUrl}/api/characterPattern/byCharacter/${characterId}`);
    console.log('Response:', response);
    if (!response.ok) {
        throw new Error(`HTTP error! in characterApiService, get character patterns by character id status: ${response.status}`);
    }
    return await response.json();
}

async function establishRelationship(characterPattern, componentId) {
    const response = await fetch(`${baseUrl}/api/characterPattern/establishRelationship?componentId=${componentId}`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(characterPattern)
    });
    if (!response.ok) {
        const errorResponse = await response.text();
        console.error('Error response:', errorResponse);
        throw new Error(`HTTP error! status: ${response.status}, message: ${errorResponse}`);
    }
    return await response.json();
}
