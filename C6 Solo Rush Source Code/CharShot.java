import greenfoot.*;  // (World, Actor, GreenfootImage, Greenfoot and MouseInfo)

/**
 * Write a description of class CharShot here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class CharShot extends Actor
{
    private int speed;
    private double x,y;
    private boolean first = true, t = false;
    
    public CharShot(int sang, int sspeed, boolean type)
    {
        setRotation(sang);
        speed=sspeed;
        if(type){
            setImage("CharShot_Vecton.png");
            speed = speed+10;
            t = true;
        }
    }
    
    
    public CharShot(int sang, int sspeed, boolean type, int side)
    {
        setRotation(sang);
        speed=sspeed;
        if(type&&side==2){
            setImage("CharShot_Vecton.png");
            speed = speed+13;
        }
        if(type&&side==1){
            setImage("CharShot_Vecton_Side.png");
            speed = speed+13;
        }
    }
    
    
    
    /**
     * Act - do whatever the CharShot wants to do. This method is called whenever
     * the 'Act' or 'Run' button gets pressed in the environment.
     */
    public void act() 
    {
        move(speed);
        if(first){
            x=getX();
            y=getY();
            first = false;
        }
     
        
        if(isTouching(Enem_Drifter.class)||isTouching(EnemShip.class)){
            if(Math.random()<.03){
                getWorld().addObject(new Radar_PowerUp(),getX(),getY());
            }
            else if(Math.random()<.05){
                getWorld().addObject(new Vecton_PowerUp(),getX(),getY());
            }
        }
        removeTouching(Cytobomber.class);
        removeTouching(EnemShip.class);
        removeTouching(Enem_Drifter.class);
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
        else if(isTouching(Entity.class)){
            Entity ene = (Entity) getObjectsInRange(1800, Entity.class).get(0);
            ene.damage();
            if(!t){ene.damage();}
            getWorld().removeObject(this);
        }
    }
}
