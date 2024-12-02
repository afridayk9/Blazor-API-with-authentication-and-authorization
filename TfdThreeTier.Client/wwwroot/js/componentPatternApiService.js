var baseUrl = 'https://localhost:7139';

async function createComponentPattern(componentPattern) {
    const response = await fetch(`${baseUrl}/api/componentPattern`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(componentPattern)
    });
    if (!response.ok) {
        const errorResponse = await response.text();
        console.error('Error response:', errorResponse);
        throw new Error(`HTTP error! status: ${response.status}, message: ${errorResponse}`);
    }
}