import greenfoot.*;  // (World, Actor, GreenfootImage, Greenfoot and MouseInfo)

/**
 * Write a description of class Credits_Win here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class Credits_Win extends Actor
{
    boolean first = true;
    /**
     * Act - do whatever the Credits_Win wants to do. This method is called whenever
     * the 'Act' or 'Run' button gets pressed in the environment.
     */
    public void act() 
    {
        if(first){
            //removeTouching()
            first = false;
        }
        if(Greenfoot.isKeyDown("r")){
            Title_Screen title_screen = new Title_Screen();
            getWorld().addObject(title_screen,getWorld().getWidth()/2,getWorld().getHeight()/2);
            Start_Button start_button = new Start_Button();
            getWorld().addObject(start_button,123,240);
            getWorld().removeObject(this);
        }
    }    
}
