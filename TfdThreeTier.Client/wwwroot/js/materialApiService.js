var baseUrl = 'https://localhost:7139';

async function getAllMaterials() {
    console.log('Fetching all materials');
    const response = await fetch(`${baseUrl}/api/material`);
    console.log('Response:', response);
    if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
    }
    return await response.json();
}

async function getMaterialById(id) {
    console.log('Fetching material with id:', id);
    const response = await fetch(`${baseUrl}/api/material/${id}`);
    console.log('Response:', response);
    if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
    }
    return await response.json();
}

async function getMaterialsByComponentId(componentId) {
    console.log('Fetching materials for component with id:', componentId);
    const response = await fetch(`${baseUrl}/api/material/byComponent/${componentId}`);
    console.log('Response:', response);
    if (!response.ok) {
        throw new Error(`HTTP error! in materialApiService,get mats by comp id. status: ${response.status}`);
    }
    return await response.json();
}

async function createMaterial(material) {
    console.log('Creating material: ', material);
    const response = await fetch(`${baseUrl}/api/material`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(material)
    });
    console.log('Response:', response);
    if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
    }
    return await response.json();
}

async function updateMaterial(material) {
    console.log('Updating material:', material);
    const response = await fetch(`${baseUrl}/api/material`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(material)
    });
    console.log('Response:', response);
    if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
    }
    return await response.json();
}

async function deleteMaterial(id) {
    console.log('Deleting material with id:', id);
    const response = await fetch(`${baseUrl}/api/material/${id}`, {
        method: 'DELETE'
    });
    console.log('Response:', response);
    if (!response.ok) {
        const errorResponse = await response.json();
        throw new Error(`HTTP error! status: ${response.status}, message: ${errorResponse.message}`);
    }
    return await response.json();
}