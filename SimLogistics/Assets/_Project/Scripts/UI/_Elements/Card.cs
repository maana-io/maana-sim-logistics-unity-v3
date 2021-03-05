using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Card : UIElement
{
    [SerializeField] protected TMP_Text title;
    [SerializeField] protected Image thumbnail;
    [SerializeField] protected Transform propertyGroup1;
    [SerializeField] protected Transform propertyGroup2;
    [SerializeField] protected Transform propertyGroup3;
    [SerializeField] protected TMP_Text notes;
    [SerializeField] protected Property propertyPrefab;
    
    public abstract void Populate(Card card, QEntity entity);

    protected void SetTitle(string text)
    {
        title.text = text;
    }

    protected void SetThumbnail(Sprite thumbnailSprite)
    {
        thumbnail.sprite = thumbnailSprite;
    }
    
    protected void AddPropertyToGroup(Transform group, string label, string value)
    {
        var property = Instantiate(propertyPrefab, group, false);
        property.Label = label;
        property.Value = value;
    }
    
    protected void AddResourceToGroup(Transform group, QResource resource)
    {
        AddPropertyToGroup(group, resource.type.id, FormatResource(resource));
    }
    
    protected string FormatResource(QResource resource)
    {
        return
        $"{resource.quantity}/{resource.capacity} @ {resource.adjustedPricePerUnit} {resource.consumptionRate}";
    }
}