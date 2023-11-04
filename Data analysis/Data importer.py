import pandas as pd
import numpy as np
import os



os.system('cls||clear')
dataframe = pd.read_csv('data.csv')

print(dataframe.to_string()) 
print(dataframe.index)
print(dataframe[['Pulse']])

def print_columns(name):
    for current_data in range(dataframe.size):
        print(dataframe.loc[current_data, name])

def locate_item(name,item_target): 
    for current_data in range(dataframe.size):
        if (dataframe.loc[current_data, name]) == item_target:
            print(dataframe.loc[current_data, name])

print_columns('Pulse')
#locate_item('Pulse','90')
