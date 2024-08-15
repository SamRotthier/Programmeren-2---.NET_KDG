window.addEventListener("load", init)
document.getElementById("submit-player").addEventListener("click", submitPlayer)
const urlParams = new URLSearchParams(window.location.search);
const guildId = urlParams.get('GuildId');
const genderMap = {
    0: "Male",
    1: "Female",
    2: "NonBinary",
    3: "Other"
};

function init() {
   getGuildsWithPlayers();
   loadPlayersForSelectBox();
}

function resetSubmittionSettings(){
    document.getElementById("player-selectbox").selectedIndex = "0"
    document.getElementById("playerJoinedOnDateTime").value = ""
}

function getGuildsWithPlayers(){
    fetch(`/api/Guilds/${guildId}`, {method: "GET"})
        .then(response => { if (response.ok){return response.json()}})
        .then(function(data) {generatePlayersInGuildTable(data)})
        .catch(() => console.error("Failed to catch the data."))
}

function generatePlayersInGuildTable(data){
    console.log(data)
    const playersInGuildTableBody= document.getElementById("player-table-body")
    playersInGuildTableBody.innerHTML=""

    if (data.length === 0){
        playersInGuildTableBody.innerHTML = '<p>No Players Found</p>'
        return;
    }

    data.playersInGuild.forEach(playerGuild =>{
        const row = document.createElement("tr")

        const cellPlayerId = document.createElement("td")
        cellPlayerId.innerText = playerGuild.player.playerId
        row.appendChild(cellPlayerId)
        
        const cellPlayerName = document.createElement("td")
        cellPlayerName.innerText = playerGuild.player.playerName
        row.appendChild(cellPlayerName)
        
        const cellPlayerGender = document.createElement("td")
        cellPlayerGender.innerText = genderMap[playerGuild.player.playerGender]
        row.appendChild(cellPlayerGender)

        const cellPlayerLevel = document.createElement("td")
        cellPlayerLevel.innerText = playerGuild.player.playerLevel
        row.appendChild(cellPlayerLevel)
        
        playersInGuildTableBody.appendChild(row)
    })
}

function loadPlayersForSelectBox(){
    fetch(`/api/Players/`, {method: "GET"})
        .then(response => { if (response.ok){return response.json()}})
        .then(players =>{
            let select = document.getElementById("player-selectbox")
            players.forEach(
                player =>{
                let option = document.createElement("option")
                option.setAttribute("value", `${player.playerId}`)
                option.innerText = `${player.playerName}`
                select.appendChild(option)})})
        .catch(() => console.error("Failed to catch the data."))
}

function submitPlayer(){
    let playerId = document.getElementById("player-selectbox").value
    let playerJoinedOn = document.getElementById("playerJoinedOnDateTime").value
    
    let playerGuild = {
        playerId : parseInt(playerId),
        guildId : parseInt(guildId),
        playerJoinedGuildOn : playerJoinedOn
    }

    fetch(`/api/PlayerGuilds/`, {
        method: "POST",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        },
        body: JSON.stringify(playerGuild)})
        .then(response => {if(response.ok){return response.json();}})
        .then(getGuildsWithPlayers).then(resetSubmittionSettings)
        .catch(error => console.error("Something went wrong with trying to add the player:", error))
}
    
