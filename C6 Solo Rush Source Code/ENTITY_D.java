import greenfoot.*;  // (World, Actor, GreenfootImage, Greenfoot and MouseInfo)

/**
 * Write a description of class ENTITY_D here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class ENTITY_D extends Actor
{
    int type, fr=0;
    public ENTITY_D(int typ){
        type = typ;
        if(type==1){
            setImage("ENTITY_D1.png");
        }
        else if(type==2){
            setImage("ENTITY_D2.png");
        }
        else if(type==3){
            setImage("ENTITY_D3.png");
        }
    }
    /**
     * Act - do whatever the ENTITY_D wants to do. This method is called whenever
     * the 'Act' or 'Run' button gets pressed in the environment.
     */
    public void act() 
    {
        if(fr%30==0){
            if(type==1){
                setLocation(getX()-1,getY()-1);
            }
            else if(type==2){
                setLocation(getX(),getY()-2);
            }
            else if(type==3){
                setLocation(getX()+1,getY()-1);
            }
        }
        if(fr==400||getY()<=3||getX()<=3||getX()>=getWorld().getWidth()-3){
            getWorld().removeObject(this);
        }
    }    
}
