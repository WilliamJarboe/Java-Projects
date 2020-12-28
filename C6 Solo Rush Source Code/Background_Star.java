import greenfoot.*;  // (World, Actor, GreenfootImage, Greenfoot and MouseInfo)

/**
 * Write a description of class Background_Star here.
 * 
 * @author (your name)
 * @version (a version number or a date)
 */
public class Background_Star extends Actor
{
    int speed;
    public Background_Star(int s){
        setRotation(90);
        speed = s;
    }
    /**
     * Act - do whatever the Background_Star wants to do. This method is called whenever
     * the 'Act' or 'Run' button gets pressed in the environment.
     */
    public void act()
    {
        move(speed);
        if(this.getY()>getWorld().getHeight()-3){
            World world;
            world = getWorld();
            world.removeObject(this);
        }
    }
}