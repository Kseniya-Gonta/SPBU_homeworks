#include "stdio.h"
#include "stdlib.h"
#pragma once

typedef struct part
{
    int key;
    int status;
    struct part* left;
    struct part* right;
} part;

part* new()
{
    part* child = (part*)malloc(sizeof(part*));
    return child;
}

int add(part* start)
{
    int m = 0;
    int i = 0;
    printf("How many elements do you want to add?  ");
    int k;
    scanf("%d", &k);
    part* pointer = start;
    int n = 0;
    while(i < k)
    {       
        pointer = start;
        scanf("%d", &n);
        m = 0;
        part* k;
        while(m == 0)
        {
            if(n > pointer -> key)
                {
                    if(pointer->right != NULL)
                    {
                        pointer = pointer->right;
                    }
                    else
                    {
                        k = new();
                        pointer->right = k;
                        k->key = n;
                        m = 1;
                        k->status = 1;
                    } 
                }
            else if(n < pointer -> key)
                {
                    if(pointer->left != NULL)
                    {
                      pointer = pointer->left;
                    }
                    else
                    {
                        k = new();
                     pointer->left = k;
                     k->key = n;
                     m = 1;
                     k->status = 1;
                    }
                }
             else
             {
                pointer->status = 1;
                m = 1;
             } 
             
        }
        i++;
    }
    return 1;  
}

int find(int n, part* start)
{
    part* pointer = start;
    if(pointer->key == n)
    {   
        if(pointer->status)
        {
            printf("Element exist in tree\n");
        }
        else
        {
            printf("No such element in the tree\n");
        }
        return 1;
            
    }
    if(n > pointer->key)
    {
        if(pointer->right != NULL)
        {
            pointer = pointer -> right;
            find(n, pointer);
        }
        else
        {
            printf("No such element in the tree\n");
            return 0;
        }
    }
    else
    {
        if(pointer->left != NULL)
        {
            pointer = pointer -> left;
            find(n, pointer);
        }
        else
        {
            printf("No such element in the tree\n");
            return 0;
        }
    }
}

int delete(int n, part* start)
{
    part* pointer = start;
    if(pointer->key == n)
    {   
        if(pointer->status)
        {
            pointer->status = 0;
        }
        else
        {
            printf("No such element in the tree\n");            
        }
        return 1;   
    }
    if(n > pointer->key)
    {
        if(pointer->right != NULL)
        {
            pointer = pointer -> right;
            delete(n, pointer);
        }
        else
        {
            printf("No such element in the tree\n");
            return 0;
        }
    }
    else
    {
        if(pointer->left != NULL)
        {
            pointer = pointer -> left;
            delete(n, pointer);
        }
        else
        {
            printf("No such element in the tree\n");
            return 0;
        }
    }
}

int main()
{
    int i = 0;
    int r = 1;
    int n;
    printf("Type header element: ");
    part* start = new();
    scanf("%d", &r);
    start->key = r;
    while(r != 0)
    {
    
        printf("What do you want to do?\n0 - nothing\n1 - add\n2 - find\n3 - delete\n");
        scanf("%d", &r);
        if(r == 0)
        {
            return 0;
        }
        else if(r == 1)
        {
            add(start);
        }
        else if(r == 2)
        {
            printf("Which element do you want to find? ");
            scanf("%d", &n);
            find(n, start);
        }   
        else if(r == 3)
        {
            printf("Which element do you want to delete? ");
            scanf("%d", &n);
            delete(n, start);  
        }
    }
    int d = start->right->key;
    printf("!%d!", d);
    return 0;
}
