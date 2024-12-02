var baseUrl = 'https://localhost:7139';

async function createComponentMaterial(componentMaterial) {
    console.log('Creating component material: ', componentMaterial);
    const response = await fetch(`${baseUrl}/api/componentMaterial`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(componentMaterial)
    });
    console.log('Response:', response);
    if (!response.ok) {
        const errorResponse = await response.text();
        console.error('Error response:', errorResponse);
        throw new Error(`HTTP error! status: ${response.status}, message: ${errorResponse}`);
    }
    return await response.json();
}