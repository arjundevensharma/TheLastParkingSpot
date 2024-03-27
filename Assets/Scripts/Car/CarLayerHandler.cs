using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLayerHandler : MonoBehaviour
{
    public SpriteRenderer carOutlineSpriteRenderer;

    List<SpriteRenderer> defaultLayerSpriteRenderers = new List<SpriteRenderer>();

    List<Collider2D> overpassColliderList = new List<Collider2D>();
    List<Collider2D> underpassColliderList = new List<Collider2D>();

    Collider2D carCollider;

    //State
    bool isDrivingOnOverpass = false;

    void Awake()
    {
        // Find all child SpriteRenderers with "Default" sorting layer and add them to the list
        foreach (SpriteRenderer spriteRenderer in gameObject.GetComponentsInChildren<SpriteRenderer>())
        {
            if (spriteRenderer.sortingLayerName == "Default")
                defaultLayerSpriteRenderers.Add(spriteRenderer);
        }

        // Find all GameObjects with "OverpassCollider" tag and add their Collider2D components to the list
        foreach (GameObject overpassColliderGameObject in GameObject.FindGameObjectsWithTag("OverpassCollider"))
        {
            overpassColliderList.Add(overpassColliderGameObject.GetComponent<Collider2D>());
        }

        // Find all GameObjects with "UnderpassCollider" tag and add their Collider2D components to the list
        foreach (GameObject underpassColliderGameObject in GameObject.FindGameObjectsWithTag("UnderpassCollider"))
        {
            underpassColliderList.Add(underpassColliderGameObject.GetComponent<Collider2D>());
        }

        // Get the Collider2D component of the car
        carCollider = GetComponentInChildren<Collider2D>();

        // Set the initial layer of the car to "ObjectOnUnderpass"
        carCollider.gameObject.layer = LayerMask.NameToLayer("ObjectOnUnderpass");
    }

    // Start is called before the first frame update
    void Start()
    {
        // Update the sorting and collision layers
        UpdateSortingAndCollisionLayers();
    }

    // Update the sorting layer and collision settings based on the driving state
    void UpdateSortingAndCollisionLayers()
    {   //outline sprite rendered affected based on if the car is driving on an overpass or not (there shouldn't be an outline when the car is driving on an overpass)
        if (isDrivingOnOverpass)
        {
            // Set the sorting layer of the car and disable the outline sprite renderer
            SetSortingLayer("RaceTrackOverpass");
            carOutlineSpriteRenderer.enabled = false;
        }
        else
        {
            // Set the sorting layer of the car and enable the outline sprite renderer
            SetSortingLayer("Default");
            carOutlineSpriteRenderer.enabled = true;
        }

        // Adjust collision settings based on the driving state
        SetCollisionWithOverPass();
    }

    // Adjust the collision settings with the overpass and underpass colliders
    void SetCollisionWithOverPass()
    {
        foreach (Collider2D collider2D in overpassColliderList)
        {
            // Ignore or enable collision between the car and the overpass colliders based on the driving state
            Physics2D.IgnoreCollision(carCollider, collider2D, !isDrivingOnOverpass);
        }

        foreach (Collider2D collider2D in underpassColliderList)
        {
            // Ignore or enable collision between the car and the underpass colliders based on the driving state
            if (isDrivingOnOverpass)
                Physics2D.IgnoreCollision(carCollider, collider2D, true);
            else
                Physics2D.IgnoreCollision(carCollider, collider2D, false);
        }
    }

    // Set the sorting layer of all default layer SpriteRenderers to the specified layer name
    void SetSortingLayer(string layerName)
    {
        foreach (SpriteRenderer spriteRenderer in defaultLayerSpriteRenderers)
        {
            spriteRenderer.sortingLayerName = layerName;
        }
    }

    // Check if the car is currently driving on the overpass
    public bool IsDrivingOnOverpass()
    {
        return isDrivingOnOverpass;
    }

    // Handle trigger collisions with underpass and overpass triggers
    void OnTriggerEnter2D(Collider2D collider2d)
    {
        if (collider2d.CompareTag("UnderpassTrigger"))
        {
            // Set the driving state to "not on overpass" and change the car's layer
            isDrivingOnOverpass = false;
            carCollider.gameObject.layer = LayerMask.NameToLayer("ObjectOnUnderpass");
            // Update the sorting and collision layers
            UpdateSortingAndCollisionLayers();
        }
        else if (collider2d.CompareTag("OverpassTrigger"))
        {
            // Set the driving state to "on overpass" and change the car's layer
            isDrivingOnOverpass = true;
            carCollider.gameObject.layer = LayerMask.NameToLayer("ObjectOnOverpass");
            // Update the sorting and collision layers
            UpdateSortingAndCollisionLayers();
        }
    }
}