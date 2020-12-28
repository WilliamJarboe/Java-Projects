import greenfoot.*;  // (World, Actor, GreenfootImage, Greenfoot and MouseInfo)

/**
 * Write a description of class False_Bullet here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class False_Bullet extends Actor
{
    int fr = 0;
    int speed;
    boolean first = true;
    int type;
    public False_Bullet(int type, int angle, int speed){
        this.speed = speed;
        setRotation(angle);
        if(type==0){
            setImage("EnemShot.png");
        }
        else if(type==1){
            setImage("Entity_Shot_1.png");
        }
        else if(type==2){
            setImage("Entity_Shot_2.png");
        }
        this.type = type;
    }
    /**
     * Act - do whatever the False_Bullet wants to do. This method is called whenever
     * the 'Act' or 'Run' button gets pressed in the environment.
     */
    public void act() 
    {
        if(first){
            
            first = false;
        }
        if(fr<=100){
            if(fr%10==0){
                move(speed/2);
            }
        }
        else{
            move(speed);
            if(getX()<2){
                World world;
                world = getWorld();
                world.removeObject(this);
            }
            else if(getY()<2){
                World world;
                world = getWorld();
                world.removeObject(this);
            }
            else if(getY()>getWorld().getHeight()-2){
                World world;
                world = getWorld();
                world.removeObject(this);
            }
            else if(getX()>getWorld().getWidth()-2){
                World world;
                world = getWorld();
                world.removeObject(this);
            }
        }
        fr++;
    }    
}
