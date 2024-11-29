var baseUrl = 'https://localhost:7139';

async function getComponentsByCharacterId(characterId) {
    console.log('Fetching components for character with id:', characterId);
    const response = await fetch(`${baseUrl}/api/component/byCharacter/${characterId}`);
    console.log('Response:', response);
    if (!response.ok) {
        throw new Error(`HTTP error! in componentApiService, get comp by char id status: ${response.status}`);
    }
    return await response.json();
}