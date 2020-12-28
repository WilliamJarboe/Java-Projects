import greenfoot.*;  // (World, Actor, GreenfootImage, Greenfoot and MouseInfo)

/**
 * Write a description of class EnemSpawner here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class EnemSpawner extends Actor
{
    private boolean randomspawns = false;
    private int fr = 0;
    private int type;
    private boolean targeted = false;
    public EnemSpawner(int t){
        type = t;
        if(t==1){
            randomspawns=false;
        }
        else if(t==2){
            randomspawns=true;
        }
    }
    
    
    /**
     * Act - do whatever the EnemSpawner wants to do. This method is called whenever
     * the 'Act' or 'Run' button gets pressed in the environment.
     */
    public void act() 
    {
        fr++;
        if(randomspawns==true){
            if(((int)(Math.random()*100))<=1){
                EnemShip enemshipA = new EnemShip(1,targeted);
                getWorld().addObject(enemshipA,((int)(Math.random()*getWorld().getWidth())),0);
            }
            if(((int)(Math.random()*100))<=1){
                Enem_Drifter enemshipB = new Enem_Drifter(1,targeted);
                getWorld().addObject(enemshipB,((int)(Math.random()*getWorld().getWidth())),0);
            }
            if(((int)(Math.random()*700))<=1){
                Cytobomber enemshipB = new Cytobomber();
                getWorld().addObject(enemshipB,((int)(Math.random()*getWorld().getWidth())),0);
            }
        }
        
        
        if(randomspawns==false){
            if(fr==25){
                EnemShip enemshipA = new EnemShip(2,targeted);
                getWorld().addObject(enemshipA,100,0);
                EnemShip enemshipB = new EnemShip(3,targeted);
                getWorld().addObject(enemshipB,getWorld().getWidth()-100,0);
            }
            if(fr==50){
                EnemShip enemshipB = new EnemShip(1,targeted);
                getWorld().addObject(enemshipB,70,0);
                EnemShip enemshipC = new EnemShip(1,targeted);
                getWorld().addObject(enemshipC,130,0);
                EnemShip enemshipD = new EnemShip(1,targeted);
                getWorld().addObject(enemshipD,getWorld().getWidth()-130,0);
                EnemShip enemshipE = new EnemShip(1,targeted);
                getWorld().addObject(enemshipE,getWorld().getWidth()-70,0);
            }
            
            if(fr==225){
                Enem_Drifter enemshipA = new Enem_Drifter(2,targeted);
                getWorld().addObject(enemshipA, getWorld().getWidth()-10, 0);
                EnemShip enemshipB = new EnemShip(3,targeted);
                getWorld().addObject(enemshipB, getWorld().getWidth()-30, 0);
                EnemShip enemshipC = new EnemShip(3,targeted);
                getWorld().addObject(enemshipC, 510, 0);
                EnemShip enemshipD = new EnemShip(3,targeted);
                getWorld().addObject(enemshipD, 490, 0);
            }
            if(fr==250){
                Enem_Drifter enemshipA = new Enem_Drifter(2,targeted);
                getWorld().addObject(enemshipA, 1, 1);
            }
            if(fr==275){
                Enem_Drifter enemshipA = new Enem_Drifter(2,targeted);
                getWorld().addObject(enemshipA, 1, 1);
            }
            
            if(fr==400){randomspawns=true;}
        }
        
        if(fr==6000){
            Entity e = new Entity();
            getWorld().addObject(e,getWorld().getWidth()/2,getWorld().getHeight()/9);
            getWorld().removeObject(this);
        }
    }
    
    public void setTarget(){
        targeted = true;
    }
}