var baseUrl = 'https://localhost:7139';

async function getAllPatterns() {
    console.log('Fetching all patterns');
    const response = await fetch(`${baseUrl}/api/pattern`);
    console.log('Response:', response);
    if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
    }
    return await response.json();
}

async function getPatternById(id) {
    console.log('Fetching pattern with id:', id);
    const response = await fetch(`${baseUrl}/api/pattern/${id}`);
    console.log('Response:', response);
    if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
    }
    return await response.json();
}

async function createPattern(pattern) {
    console.log('Creating pattern: ', pattern);
    const response = await fetch(`${baseUrl}/api/pattern`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(pattern)
    });
    console.log('Response:', response);
    if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
    }
    return await response.json();
}

async function updatePattern(pattern) {
    console.log('Updating pattern:', pattern);
    const response = await fetch(`${baseUrl}/api/pattern`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(pattern)
    });
    console.log('Response:', response);
    if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
    }
    return await response.json();
}

async function deletePattern(id) {
    console.log('Deleting pattern with id:', id);
    const response = await fetch(`${baseUrl}/api/pattern/${id}`, {
        method: 'DELETE'
    });
    console.log('Response:', response);
    if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
    }
    return await response.json();
}


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