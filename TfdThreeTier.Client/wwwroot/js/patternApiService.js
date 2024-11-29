var baseUrl = 'https://localhost:7139';


async function getPatternsByMaterialId(materialId) {
    console.log('Fetching patterns for material with id:', materialId);
    const response = await fetch(`${baseUrl}/api/pattern/byMaterial/${materialId}`);
    console.log('Response:', response);
    if (!response.ok) {
        throw new Error(`HTTP error! in patterApiService, get pat by mat id status: ${response.status}`);
    }
    return await response.json();
}

async function getPatternsByComponentId(componentId) {
    console.log('Fetching patterns for component with id:', componentId);
    const response = await fetch(`${baseUrl}/api/pattern/byComponent/${componentId}`);
    console.log('Response:', response);
    if (!response.ok) {
        throw new Error(`HTTP error! in patternApiService, get patterns by component id status: ${response.status}`);
    }
    return await response.json();
}

async function getPatternsByCharacterId(characterId) {
    console.log('Fetching patterns for character with id:', characterId);
    const response = await fetch(`${baseUrl}/api/pattern/byCharacter/${characterId}`);
    console.log('Response:', response);
    if (!response.ok) {
        throw new Error(`HTTP error! in patternApiService, get patterns by character id status: ${response.status}`);
    }
    return await response.json();
}