var baseUrl = 'https://localhost:7139';

//function to establish relationship between character and component
async function createCharacterComponent(characterComponent) {
    console.log('Creating character component: ', characterComponent);
    const response = await fetch(`${baseUrl}/api/characterComponent`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(characterComponent)
    });
    console.log('Response:', response);
    if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
    }
    return await response.json();
}