window.addEventListener('DOMContentLoaded', (event) => {
    getVisitCount();
})

const functionApiUrl = 'https://counter049578.azurewebsites.net/api/GetVisitorCounter?code=yPqVsgAlyusoAdxdd3E39kEm0RDEsfqk75PyNfTUaSquAzFuDEa33Q==';
const localFunctionApi = 'http://localhost:7071/api/GetVisitorCounter';

const getVisitCount = () => {
    let count = 30;
    fetch(functionApiUrl).then(response => {
        return response.json()
    }).then(response => {
        console.log("Website called function API.");
        count = response.count;
        document.getElementById("counter").innerText = count;
    }).catch(function(error){
        console.log(error);
    });
    return count;
}