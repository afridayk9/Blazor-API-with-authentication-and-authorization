var baseUrl = 'https://localhost:7139';

async function createComponent(component) {
    console.log('Creating component: ', component);
    const response = await fetch(`${baseUrl}/api/component`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(component)
    });
    console.log('Response:', response);
    if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
    }
    return await response.json();
}

async function deleteComponent(id) {
    console.log('Deleting component with id:', id);
    const response = await fetch(`${baseUrl}/api/component/${id}`, {
        method: 'DELETE'
    });
    console.log('Response:', response);
    if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
    }
    return await response.json();
}

async function getAllComponents() {
    console.log('Fetching all components');
    const response = await fetch(`${baseUrl}/api/component`);
    console.log('Response:', response);
    if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
    }
    return await response.json();
}

async function getComponentById(id) {
    console.log('Fetching component with id:', id);
    const response = await fetch(`${baseUrl}/api/component/${id}`);
    console.log('Response:', response);
    if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
    }
    return await response.json();
}

async function updateComponent(component) {
    console.log('Updating component:', component);
    const response = await fetch(`${baseUrl}/api/component`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(component)
    });
    console.log('Response:', response);
    if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
    }
    return await response.json();
}

async function getComponentsByCharacterId(characterId) {
    console.log('Fetching components for character with id:', characterId);
    const response = await fetch(`${baseUrl}/api/component/byCharacter/${characterId}`);
    console.log('Response:', response);
    if (!response.ok) {
        throw new Error(`HTTP error! in componentApiService, get comp by char id status: ${response.status}`);
    }
    return await response.json();
}






