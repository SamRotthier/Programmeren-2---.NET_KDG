window.addEventListener("load", getMonsters)

document.getElementById("refresh-button").addEventListener("click", getMonsters)


const genderMap = {
    0: "Male",
    1: "Female",
    2: "NonBinary",
    3: "Other"
};

function getMonsters(){
    fetch("/api/Monsters/", {method: "GET"})
        .then(response => { if (response.ok){return response.json()}})
        .then(function(data) {generateMonsterTable(data)})
        .catch(() => console.error("Failed to catch the data."))
}

function generateMonsterTable(data){
    //console.log(data)
   const monsterTableBody= document.getElementById("monster-table-body")
    monsterTableBody.innerHTML="" 
    
   if (data.length === 0){
       monsterTableBody.innerHTML = '<p>No Monsters Found</p>'
       return;
   }
   
   data.forEach(monster =>{
       const row = document.createElement("tr")

       const cellMonsterName = document.createElement("td")
       cellMonsterName.innerText = monster.monsterName
       row.appendChild(cellMonsterName)

       const cellMonsterGender = document.createElement("td")
       cellMonsterGender.innerText = genderMap[monster.monsterGender]
       row.appendChild(cellMonsterGender)

       const cellMonsterLevel = document.createElement("td")
       cellMonsterLevel.innerText = monster.monsterLevel
       row.appendChild(cellMonsterLevel)

       const cellMonsterHealth = document.createElement("td")
       cellMonsterHealth.innerText = monster.monsterHealth
       row.appendChild(cellMonsterHealth)

       const cellMonsterCanEvolve = document.createElement("td")
       cellMonsterCanEvolve.innerText = monster.monsterCanEvolve
       row.appendChild(cellMonsterCanEvolve)

       monsterTableBody.appendChild(row)
   })
   
}