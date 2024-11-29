var baseUrl = 'https://localhost:7139';

async function getCharacterPatternsByCharacterId(characterId) {
    console.log('Fetching character patterns for character with id:', characterId);
    const response = await fetch(`${baseUrl}/api/characterPattern/byCharacter/${characterId}`);
    console.log('Response:', response);
    if (!response.ok) {
        throw new Error(`HTTP error! in characterApiService, get character patterns by character id status: ${response.status}`);
    }
    return await response.json();
}