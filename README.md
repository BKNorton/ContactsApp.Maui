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
  I also learned new architectures to help construct the app in ways that is more modularized to seperate the UI from the UI logic and the business logic. This is helpful in the development process so that multiple people can be working on different parts of the project at the same time. 
</p>
<ul>
  <li>MVVM or Model-View-ViewModel allows UI development to be done seperate from all logic implementation.</li>
  <li>Clean Architecture layers everything around the core business logic. This allows you to seperate the dependency of the databse so if the type of database changes you can just use dependency injection to switch out the repository</li>
  <ul><li>Use Cases are the layer outside the buisness logic that use repository plugins to work with the database</li></ul>
</ul>
<h2>
  Next Steps
</h2>
  
