
using Assets.Model.SQL;
using System.Collections.Generic;


public class gameModel
{
    /*=======================================+Stores Objects related to game state+=============================================*/
    public scene currentScene;
    public string sceneCode = "Master's Room";
    public character playerCharacter;
    private List<sqlScenes> defaultScenes = new List<sqlScenes>();
    /*=======================================-Stores Objects related to game state-=============================================*/


    /*=======================================+Sets up game scenes+=============================================*/
    private void makeStory()
    {

        sqlScenes mastersRoom = new sqlScenes {

          sceneName = "Master's Room",

    sceneDiscription = "You enter a drab room. On an old dusty crate sits" +
                " an old man wearing a mangy robe which drapes off his " +
                "arms, highlighting the fact that this man doesn't have any hands" +
                ". This is the man you know to be The Master. What do you do?",
    adjasentText = "is a swirling portal.",
    obstricalFrame = "stands in front of a swirling portal."


};
            defaultScenes.Add(mastersRoom);
       
     

        sqlScenes glowingPool = new sqlScenes
        {

            sceneName = "Glowing Pool",

            sceneDiscription = "You enter into a large cavern with crystalline walls." +
                " The faintest gleam of light manages to shimmer through the tarnished crystal surfaces. " +
                "A large pillar rises from the centre of the room, on top of which sits a smiling imp. " +
                "A pool of glowing liquid shimmers ominously to the west. What do you do?",
            adjasentText = "an aluring glow calls to you.",
            obstricalFrame = "blocks a faint glow."


        };



        defaultScenes.Add(glowingPool);

        sqlScenes fancyHouse = new sqlScenes
        {

            sceneName = "Fancy House",

            sceneDiscription = "You sit in a well ferbised house, surounded by soft," +
            " why would you want to leave?",
            adjasentText = "a nice house.",
            obstricalFrame = "gaurds."


        };



        defaultScenes.Add(fancyHouse);

        sqlScenes bigTree = new sqlScenes
        {

            sceneName = "Big Tree",

            sceneDiscription = "You can't see the top of this tree, it's so tall.",
            adjasentText = "a tree which strangles the skyline.",
            obstricalFrame = "climbs from."


        };



        defaultScenes.Add(bigTree);



        GameManager.instance.DatabaseServices.Connection.InsertOrReplace(defaultScenes[0]);
        GameManager.instance.DatabaseServices.Connection.InsertOrReplace(defaultScenes[1]);
        GameManager.instance.DatabaseServices.Connection.InsertOrReplace(defaultScenes[2]);
        GameManager.instance.DatabaseServices.Connection.InsertOrReplace(defaultScenes[3]);
    }


    /*=======================================-Sets up game scenes-=============================================*/

    /*=======================================+Runs makeStory on start up+=============================================*/
    public gameModel()
    {
        makeStory();
    }

    /*=======================================-Runs makeStory on start up-=============================================*/



}
