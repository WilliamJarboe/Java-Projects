import greenfoot.*;  // (World, Actor, GreenfootImage, Greenfoot and MouseInfo)

/**
 * Write a description of class Entity_Shot_2 here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class Entity_Shot_2 extends Actor
{
    int spd = 5, fx, fy, trueang;
    boolean first = true;
    double x, y;
    public Entity_Shot_2(int spd, int x, int y){
        fx = x; fy = y;
        this.spd = spd;
    }
    
    /**
     * Act - do whatever the Entity_Shot_2 wants to do. This method is called whenever
     * the 'Act' or 'Run' button gets pressed in the environment.
     */
    public void act() 
    {
        if(first){
            turnTowards(fx,fy);
            trueang = getRotation();
            first = false;
            x = getX();
            y = getY();
        }
        x = x+((Math.cos(trueang*Math.PI/180))*spd);
        y = y+((Math.sin(trueang*Math.PI/180))*spd);
        setLocation((int)x,(int)y);
        turn(15);
        if(isTouching(Char.class)){
            getWorld().addObject(new False_Bullet(2,trueang,spd),getX(),getY());
            getWorld().showText(null,50,getWorld().getHeight()-45);
            getWorld().showText(null,50,getWorld().getHeight()-15);
            getWorld().addObject(new GameOver_Screen(), getWorld().getWidth()/2,getWorld().getHeight()/2);
            try{
                Char ene = (Char) getObjectsInRange(1800, Char.class).get(0);
                turnTowards(ene.getX(),ene.getY());
            } catch(Exception e){}
            getWorld().addObject(new Char_Dead_Piece(getRotation()-16,spd),getX(),getY());
            getWorld().addObject(new Char_Dead_Piece(getRotation()-6,spd),getX(),getY());
            getWorld().addObject(new Char_Dead_Piece(getRotation()+6,spd),getX(),getY());
            getWorld().addObject(new Char_Dead_Piece(getRotation()+16,spd),getX(),getY());
        }
        removeTouching(Char.class);
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
