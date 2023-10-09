export function formatDate(date) {
    var mn = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];

    var d = new Date(date),
        month = '' + mn[(d.getMonth())],
        day = ('' + d.getDate()).padStart(2, '0'),
        year = d.getFullYear();

    return [day, month, year].join('-');
}

export const getData = async (url) => {

    const response = await fetch(`https://localhost:7108/api/${url}`, {
        method: 'GET', // or 'POST', 'PUT', etc.
        headers: {
            'Access-Control-Allow-Origin': '*',
            'Content-Type': 'application/json',
        }
    });

    const fetchedData = await response.json(response);
    return fetchedData;
}