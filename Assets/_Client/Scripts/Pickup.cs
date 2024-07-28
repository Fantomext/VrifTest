using System;
using System.Collections;
using System.Collections.Generic;
using BNG;
using UnityEngine;
using Random = UnityEngine.Random;


public class Pickup : Grabbable
{
    public Action OnDrop;
    public Action OnGrab;

    [SerializeField] private Material _material;
    private Color _defaultColor;

    private void Start()
    {
        _defaultColor = new Color(_material.color.r, _material.color.g, _material.color.b, 255);
    }

    private void OnEnable()
    {
        OnDrop += ChangeColorToDefalut;
        OnGrab += ChangeColorToRandom;
    }

    private void OnDisable()
    {
        OnDrop -= ChangeColorToDefalut;
        OnGrab -= ChangeColorToRandom;
    }

    //Переписали метод GrabItem
    public override void GrabItem(Grabber grabbedBy)
    {
        OnGrab.Invoke();
        base.GrabItem(grabbedBy);
    }

    //Переписали метод Dropitem
    public override void DropItem(Grabber droppedBy)
    {
        OnDrop.Invoke();
        base.DropItem(droppedBy);
    }

    //В данном методе возвращаем изначальный цвет предмету
    private void ChangeColorToDefalut()
    {
        _material.color = new Color(_defaultColor.r, _defaultColor.g, _defaultColor.b, 255);
    }

    //В данном методе задаем случайный цвет предмету
    private void ChangeColorToRandom()
    {
        _material.color = new Color(Random.Range(0,255f)/255,Random.Range(0,255f)/255,Random.Range(0,255f)/255, 1);
    }
}
