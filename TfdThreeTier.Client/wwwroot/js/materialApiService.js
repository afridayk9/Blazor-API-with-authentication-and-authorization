var baseUrl = 'https://localhost:7139';


async function getMaterialsByComponentId(componentId) {
    console.log('Fetching materials for component with id:', componentId);
    const response = await fetch(`${baseUrl}/api/material/byComponent/${componentId}`);
    console.log('Response:', response);
    if (!response.ok) {
        throw new Error(`HTTP error! in materialApiService,get mats by comp id. status: ${response.status}`);
    }
    return await response.json();
}