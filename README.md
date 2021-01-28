# PostGradCollab
Collaboration of graduates of devCodeCamp to design a website for post grads to collaborate and present their work and porfolios.


# Using Webpack and React inside of this project through ReactJs.Net

The project is currently configured to render server side jsx through webpack. It is recommended and required in most instances, to run 'npx webpack' prior to starting a new instance of the server, Hot Reloading has not been tested as when webpack rebundles outside of 'npx webpack' is unsure in this structure.

To add a new component file to be imported into another component already visible to the app, you can proceed as normal making sure to run 'npx webpack' (Hot reloading: In dev)

To add a new component file to be loaded independently of one of the root-components, first export the default component class as normal. In 'expose-components.js' at an Import statement "Import myComponent from './NewComponentFile.jsx';"  At the bottom, insert "myComponent" into the global components. "global.Components = { ThisComponent, ThatComponent, myComponent };"
Last on your "View" page use the Html Helper, "@Html.React("Components.myComponent", new { *insert props here, either from c# or manually* })"





## News
January 19th, 
   Per consensus at last meeting, Project structure has been changed to reflect the addition/change to utilizing ReactJs.Net allowing for full MVC usage with client or server-side rendering of React Components within views (or a base SPA running off of a main controller.) Dumby examples of a Post and Post comment class have been added for John E. to continue work on post components.

## Future
   Katelynn T. will be beginning work on the Repository Design Pattern implementation, while she and others continue work on the ERD.
   Tim H. will test implementing an Authentification/Authorization schema.
   
## Contact
Questions please contact Tim at tmherron09@gmail.com or for devCodeCamp past/current students please feel free to reach out on Slack.
