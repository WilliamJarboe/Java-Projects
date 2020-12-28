import greenfoot.*;  // (World, Actor, GreenfootImage, Greenfoot and MouseInfo)

/**
import greenfoot.*;  // (World, Actor, GreenfootImage, Greenfoot and MouseInfo)

/**
 * Write a description of class EnemShot here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class Entity_Shot_1 extends Actor
{
    int speed = 5, fr = 0, r, fx, fy;
    double x, y;
    boolean first = true;
    boolean initiatedR = false;
    public Entity_Shot_1(int r, int s)
    {
        setRotation(r);
        this.r = r;
        speed = s+9;
        initiatedR = true;
    }
    
    public Entity_Shot_1(int spd, int x, int y){
        fx = x; fy = y;
        speed = spd;
    }
    
    
    /**
     * Act - do whatever the EnemShot wants to do. This method is called whenever
     * the 'Act' or 'Run' button gets pressed in the environment.
     */
    public void act() 
    {
        if(first){
            x = getX();
            y = getY();
            first = false;
            if(initiatedR==false){
                turnTowards(fx, fy);
                r = getRotation();
            }
        }
        x = x+((Math.cos(r*Math.PI/180))*speed);
        y = y+((Math.sin(r*Math.PI/180))*speed);
        setLocation((int)x,(int)y);
        if(fr==30){speed = speed-9;}
        
        if(isTouching(Char.class)){
            removeTouching(Char.class);
            getWorld().addObject(new False_Bullet(1,r,speed),getX(),getY());
            getWorld().showText(null,50,getWorld().getHeight()-45);
            getWorld().showText(null,50,getWorld().getHeight()-15);
            getWorld().addObject(new Char_Dead_Piece(getRotation()-66,speed),getX(),getY());
            getWorld().addObject(new Char_Dead_Piece(getRotation()-86,speed),getX(),getY());
            getWorld().addObject(new Char_Dead_Piece(getRotation()+86,speed),getX(),getY());
            getWorld().addObject(new Char_Dead_Piece(getRotation()+66,speed),getX(),getY());
            getWorld().addObject(new GameOver_Screen(), getWorld().getWidth()/2,getWorld().getHeight()/2);
        }
        fr++;
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
}
