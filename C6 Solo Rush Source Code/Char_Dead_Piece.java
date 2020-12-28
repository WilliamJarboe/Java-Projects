import greenfoot.*;  // (World, Actor, GreenfootImage, Greenfoot and MouseInfo)

/**
 * Write a description of class Char_Dead_Piece here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class Char_Dead_Piece extends Actor
{
    boolean first = true;
    int speed;
    int fr = 0;
    public Char_Dead_Piece(int angle,int speed){
        setRotation(angle);
        this.speed = speed;
    }
    /**
     * Act - do whatever the Char_Dead_Piece wants to do. This method is called whenever
     * the 'Act' or 'Run' button gets pressed in the environment.
     */
    public void act()
    {
        if(first){
            move(30);
            first = false;
        }
        if(fr<=100){
            if(fr%10==0){
                move(speed/2);
            }
        }
        else if(fr>100){
            move(speed);
        }
        fr++;
        if(getX()<3){
            setRotation(180-getRotation());
        }
        if(getY()<3){
            setRotation(180-getRotation());
        }
        if(getX()>getWorld().getWidth()-3){
            setRotation(180-getRotation());
        }
        if(getY()>getWorld().getHeight()-3 || fr>140){
            getWorld().removeObject(this);
        }
    }
}
