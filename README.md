<h1>
  Description
</h1>
<p>
  I created this project while taking a Udemy course. This was just something I made while following along with the course. I plan to use what I learned here to create the inventory app that I am working on. (I have already built the web api for it and the UI for most of it)

  This app allows users to add, delete, edit, and view their contacts and persists the data in a SQLite database in local memory.

  This project uses Clean Architecture and MVVM principles to keep all the layers loosely coupled.

  This app was made for mobile devices not Windows.

  This project contains different implementations because of how the course layerd the lessons to build on what you learned.
</p>
<h2>
  The Process
</h2>
<p>
  First this app was built to be event driven. It also only used a static repository with a predefined list of contacts.

  New contacts or edits to contacts could not be persisted and all changes were lost when the program stopped running.

  Then this app was modified to use clean architecture.
</p>
<ul>
  <li>This is a buisness centric model where all other outside layers are dependant on the entities.</li>
  <li>It uses Use Cases to perform actions on the Repository that is pluged in.</li>
  <li>With the use of dependency injection you can consume the Use Cases without worrying about where the data is or what repository you are using.</li>
</ul>
<p>
  Then the course had you add a SQLite database so the user could persit all their data into an inmemory database/
</p>
<h2>
  What I learned
</h2>
<p>
  I learned how to build UIs using XAML
</p>
<ul>
  <li>Responsive to user input</li>
  <li>Two-way data binding</li>
  <li>Visually appealing and intuitive</li>
  <li>Design for different device specifications</li>
</ul>
<p>
  I also learned new architectures to help construct apps in ways that is more modularized to seperate the UI from the UI logic and the business logic. This is helpful in the development process so that multiple people can be working on different parts of the project at the same time. 
</p>
<ul>
  <li>MVVM or Model-View-ViewModel allows UI development to be done seperate from all logic implementation.</li>
  <li>Clean Architecture layers everything around the core business logic. This allows you to seperate the dependency of the databse so if the type of database changes you can just use dependency injection to switch out the repository</li>
  <ul><li>Use Cases are the layer outside the buisness logic that use repository plugins to work with the database</li></ul>
</ul>
<h2>
  Next Steps
</h2>
<p>
  I am on the last module of this course. The last module is where I will use entity framework with a web api to work with the database.
</p>
<ol>
  <li>Finish Udemy course and commit changes.</li>
  <li>Use as a refrence and continue working on my Item Inventory app.</li>
</ol>
<h1>
  Instructions
</h1>
<h2>
  How to run application
</h2>
<ol>
  <li>After cloning the repository down, open up the Solution.</li>
  <li>In the dropdown for the debugger, go into Android Device Manager and add a new Emulator. I am using Pixel 5 API33</li>
  
  ![Screenshot (24)](https://github.com/BKNorton/ContactsApp.Maui/assets/112774855/7666ffd9-a111-4fa1-bda8-05d680593b08)

  <li>Select the emulator and run it.</li>
  <ul><li>Do not run in windows. There are bugs that crash the project in windows when I have tried it.</li></ul>
  <li>You can add new contacts by clicking the add button</li>
  <ul><li>Name and Email are required and Email must be properly formatted.</li></ul>
  <li>You can swipe a contact from the Contacts page to the left to access the Edit or Delete buttons for the particular Contact.</li>
  <p>
    <img height="475" 
      width="350"
      src="https://github.com/BKNorton/ContactsApp.Maui/assets/112774855/fe507ba2-ecf7-4bdd-adc4-7ce83b67c277"/>
    <img height="475" 
      width="300"
      src="https://github.com/BKNorton/ContactsApp.Maui/assets/112774855/811e3f7c-7f69-4e5d-83df-c9f5023b542e"/>
  </p>
  
  <li>You can use the searchbar to look for a specific Contact by any of its properties.</li>
</ol>

 
