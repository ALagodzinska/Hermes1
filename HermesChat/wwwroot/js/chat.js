"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

var groupName = null;

//Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;

connection.on("GetOnlineUsers", function (usersList) {
    console.log(usersList);
    Array.from(usersList);
    var onlineUsers = document.getElementById("user-list");
    onlineUsers.innerHTML = "";
    usersList.forEach(addOneUser);
});
function addOneUser(user) {
    var li = document.createElement("li");
    li.innerHTML = `<p>${user}</p>`;
    document.getElementById("user-list").appendChild(li);
}


connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    li.textContent = `${user}: ${message}`;
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var message = document.getElementById("messageInput").value;
    
    document.getElementById("messageInput").value = "";
    if (groupName !== null) {
        connection.invoke("SendMessage", message, groupName).catch(function (err) {
            return console.error(err.toString());
        });
    }
    event.preventDefault();
});

document.getElementById("joinButton").addEventListener("click", function (event) {

    var room = document.getElementById("room").value;
    document.getElementById("messagesList").innerHTML = "";
    connection.invoke("CreateRoom", room).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

connection.on("GetRoomList", function (roomList) {
    console.log(roomList);
    Array.from(roomList);
    var roomWindow = document.getElementById("room-list");
    roomWindow.innerHTML = "";
    roomList.forEach(addOneRoom);
});

function addOneRoom(room) {
    var li = document.createElement("li");
    var button = document.createElement("button");
    button.textContent = room;
    button.onclick = function (event) {
        document.getElementById("messagesList").innerHTML = "";
        groupName = room;
        connection.invoke("CreateRoom", room).catch(function (err) {
            return console.error(err.toString());
        });
    }
    li.appendChild(button);
    document.getElementById("room-list").appendChild(li);
}

function scrollDown() {
  $('#messages_container').animate({scrollTop:$('#messages_container').prop('scrollHeight')}, 1000);
}

