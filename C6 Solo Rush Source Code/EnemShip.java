import greenfoot.*;  // (World, Actor, GreenfootImage, Greenfoot and MouseInfo)

/**
 * Write a description of class EnemShip here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class EnemShip extends Actor
{
    private boolean first = true, crazy = false;
    int s = 0, aiType = 1, fr = 0;
    int modA = 0;
    public EnemShip(int ait, boolean targeted){
        aiType = ait;
        if(targeted){
            setImage("EnemShip_Targeted.png");
        }
    }
    /**
     * Act - do whatever the EnemShip wants to do. Which is make life as hard as possible for Char.
     * This method is called whenever
     * the 'Act' or 'Run' button gets pressed in the environment.
     */
    public void act() 
    {
        fr++;
        if(first){
            setRotation(90);
            first = false;
        }
        
        if(aiType==1){
            if(getY()<40){
                move(2);
            }
            if(getY()==40){
                EnemShot EnemShotA = new EnemShot(getRotation());
                getWorld().addObject(EnemShotA, getX(), getY());
                EnemShot EnemShotB = new EnemShot(getRotation()+15);
                getWorld().addObject(EnemShotB, getX(), getY());
                EnemShot EnemShotC = new EnemShot(getRotation()-15);
                getWorld().addObject(EnemShotC, getX(), getY());
                move(1);
            }
            if(getY()>40){
                move(2);
            }
        }
        
        if(aiType==2){
            if(getY()<160){move(3);}
            if(fr%6==0&&fr<=500&&getY()>=160){
                int c = 0;
                EnemShot EnemShotA;
                EnemShot EnemShotB;
                EnemShot EnemShotC;
                while(c<6){
                    EnemShotA = new EnemShot((c*60)+modA);
                    getWorld().addObject(EnemShotA, getX(), getY());
                    EnemShotB = new EnemShot((c*60)+modA,6);
                    getWorld().addObject(EnemShotB, getX(), getY());
                    EnemShotC = new EnemShot((c*60)+modA,4);
                    getWorld().addObject(EnemShotC, getX(), getY());
                    c++;
                }
                modA = modA+1;
            }
            if(fr>700){move(4);}
        }
        
        if(aiType==3){
            if(getY()<160){move(3);}
            if(fr%6==0&&fr<=500&&getY()>=160){
                int c = 0;
                EnemShot EnemShotA;
                EnemShot EnemShotB;
                EnemShot EnemShotC;
                while(c<6){
                    EnemShotA = new EnemShot((c*60)+modA);
                    getWorld().addObject(EnemShotA, getX(), getY());
                    EnemShotB = new EnemShot((c*60)+modA,6);
                    getWorld().addObject(EnemShotB, getX(), getY());
                    EnemShotC = new EnemShot((c*60)+modA,4);
                    getWorld().addObject(EnemShotC, getX(), getY());
                    
                    c++;
                }
                modA = modA-3;
            }
            if(fr>700){move(4);}
        }
        
        
        if(getY()>getWorld().getHeight()-5){
            World world;
            world = getWorld();
            world.removeObject(this);
        }
    }
}