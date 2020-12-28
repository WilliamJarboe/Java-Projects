import greenfoot.*;  // (World, Actor, GreenfootImage, Greenfoot and MouseInfo)

/**
 * Write a description of class Enem_Drifter here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class Enem_Drifter extends Actor
{
    private boolean first = true, crazy = false, targeted = false;
    int s = 0, aiType;
    
    public Enem_Drifter(int ait, boolean targeted){
        aiType = ait;
        if(targeted){
            setImage("Enem_Drifter_Targeted.png");
        }
    }
    /**
     * Act - do whatever the EnemShip wants to do. Which is make life as hard as possible for Char.
     * This method is called whenever
     * the 'Act' or 'Run' button gets pressed in the environment.
     */
    public void act() 
    {
        
        if(first){
            setRotation(90);
            first = false;
        }
        if(aiType==1){
            if(getY()<40){
                move(1);
            }
            if(getY()==40){
                EnemShot EnemShotA = new EnemShot(getRotation()+20);
                getWorld().addObject(EnemShotA, getX(), getY());
                EnemShot EnemShotB = new EnemShot(getRotation()+15);
                getWorld().addObject(EnemShotB, getX(), getY());
                EnemShot EnemShotC = new EnemShot(getRotation()-15);
                getWorld().addObject(EnemShotC, getX(), getY());
                EnemShot EnemShotD = new EnemShot(getRotation()-20);
                getWorld().addObject(EnemShotD, getX(), getY());
                move(1);
            }
            if(getY()>40){
                move(3);
            }
        
            if(getY()>40&&((int)(Math.random()*100))<1)
            {
                EnemShot EnemShotA = new EnemShot(getRotation()+20);
                getWorld().addObject(EnemShotA, getX(), getY());
                EnemShot EnemShotB = new EnemShot(getRotation()+15);
                getWorld().addObject(EnemShotB, getX(), getY());
                EnemShot EnemShotC = new EnemShot(getRotation()-15);
                getWorld().addObject(EnemShotC, getX(), getY());
                EnemShot EnemShotD = new EnemShot(getRotation()-20);
                getWorld().addObject(EnemShotD, getX(), getY());
            }
        }
        
        if(aiType==2){
            if(getRotation()>0&&getX()<300){
                turn(-3);
            }
            move(4);
            if(getX()<300){
                EnemShot EnemShotA = new EnemShot(90,4);
                getWorld().addObject(EnemShotA, getX(), getY());
            }
            else if(getRotation()==0){
                turn(-1);
            }
            else if(getRotation()>310){
                turn(-3);
            }
        }
        
        if(aiType==3){
            if(getRotation()<180&&getX()>300){
                turn(3);
            }
            move(4);
            if(getX()>300){
                EnemShot EnemShotA = new EnemShot(90,4);
                getWorld().addObject(EnemShotA, getX(), getY());
            }
            else if(getRotation()==180){
                turn(1);
            }
            else if(getRotation()<210){
                turn(3);
            }
        }
        
        
        if(getY()>getWorld().getHeight()-5||(aiType==2&&(getY()<2&&getX()>300))||(aiType==3&&(getY()<2&&getX()<300))){
            World world;
            world = getWorld();
            world.removeObject(this);
        }
    }
}
//they're so hard to hit without radar powerup omg