window.addEventListener('DOMContentLoaded', (event) => {
    getVisitCount();
})

const functionApi = 'http://localhost:7071/api/GetVisitorCounter';

const getVisitCount = () => {
    let count = 30;
    fetch(functionApi).then(response => {
        return response.json()
    }).then(response => {
        console.log("Website called function API.");
        count = response.count;
        document.getElementById("count").innerText = count;
    }).catch(function(error){
        console.log(error);
    });
    return count;
}