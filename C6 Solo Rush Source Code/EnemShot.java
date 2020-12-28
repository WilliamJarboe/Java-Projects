import greenfoot.*;  // (World, Actor, GreenfootImage, Greenfoot and MouseInfo)

/**
 * Write a description of class EnemShot here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class EnemShot extends Actor
{
    int speed = 5;
    boolean firstA = false, first = true;
    int x,y;
    public EnemShot(int r)
    {
        setRotation(r);
    }
    public EnemShot(int r, int s)
    {
        setRotation(r);
        speed = s;
    }
    public EnemShot(int r, int s, int x, int y){
        setRotation(r);
        speed = s;
        firstA=true;
        this.x=x;
        this.y=y;
    }
    
    
    /**
     * Act - do whatever the EnemShot wants to do. This method is called whenever
     * the 'Act' or 'Run' button gets pressed in the environment.
     */
    public void act() 
    {
        move(speed);
        if(firstA){turnTowards(x,y);firstA=false;}
        if(first){setImage("EnemShot.png");first=false;}
        
        if(isTouching(Char.class)){
            getWorld().addObject(new False_Bullet(0,getRotation(),speed),getX(),getY());
            getWorld().showText(null,50,getWorld().getHeight()-45);
            getWorld().showText(null,50,getWorld().getHeight()-15);
            try{
                Char ene = (Char) getObjectsInRange(1800, Char.class).get(0);
                getWorld().addObject(new GameOver_Screen(ene.getScore()),getWorld().getWidth()/2,getWorld().getHeight()/2);
            } catch(Exception e){}
            getWorld().addObject(new Char_Dead_Piece(getRotation()-66,speed),getX(),getY());
            getWorld().addObject(new Char_Dead_Piece(getRotation()-86,speed),getX(),getY());
            getWorld().addObject(new Char_Dead_Piece(getRotation()+86,speed),getX(),getY());
            getWorld().addObject(new Char_Dead_Piece(getRotation()+66,speed),getX(),getY());
            removeTouching(Char.class);
        }
        
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
