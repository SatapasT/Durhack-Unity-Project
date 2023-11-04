import pandas as pd
import numpy as np
import os
import matplotlib.pyplot as plt

os.system('cls')

#dataframe = pd.DataFrame(data=data_import)
csv_name= os.path.join(os.path.dirname(__file__), "data.csv")
df = pd.read_csv(csv_name)

#print(dataframe.to_string()) 
#print(dataframe.index)
#print(dataframe[['Pulse']])

def print_columns_value(dataframe,column_name):
    temp_array = []
    for current_data in range(len(dataframe)):
        temp_array.append(dataframe.loc[current_data, column_name])
    return temp_array

def datasize(dataframe):
    count = 0
    for current_data in range(len(dataframe)):
        count += 1
    return count

def return_dataframe_totext(dataframe):
    return dataframe.to_string()

# 1:greater than, 2:less than, 3:equal, 4:not equal
def filter_by_number(dataframe, column_name, operator, size):
    if operator == 1:
        return dataframe[dataframe[column_name] > size]
    elif operator == 2:
        return dataframe[dataframe[column_name] < size]
    elif operator == 3:
        return dataframe[dataframe[column_name] == size]
    elif operator == 4:
        return dataframe[dataframe[column_name] != size]

# 1:Equal, 2:not equal
def filter_by_name(dataframe, column_name, operator, name):
    if operator == 1:
        return dataframe[dataframe[column_name] == name]
    elif operator == 2:
        return dataframe[dataframe[column_name] != name]
    
def sum_of_columns(dataframe, column_name):
    return np.sum(dataframe[column_name])

def mean_of_columns(dataframe, column_name):
    return np.mean(dataframe[column_name])

def median_of_columns(dataframe, column_name):
    return np.median(dataframe[column_name])

def mode_of_columns(dataframe, column_name):
    temp_array = []
    temp_array2 = []
    count = 0
    for current_data in range(len(dataframe)):
        if dataframe.loc[current_data, column_name] not in temp_array2:
            temp_array.append(dataframe.loc[current_data, column_name])
            temp_array2.append(1)
        else:
            temp_array2[temp_array.index(dataframe.loc[current_data, column_name])] += 1
        return temp_array[temp_array2.index(max(temp_array2))]
    
def mode_of_columns(dataframe, column_name):
    temp_array = []
    temp_array2 = []
    count = 0
    for current_data in range(len(dataframe)):
        if dataframe.loc[current_data, column_name] not in temp_array2:
            temp_array.append(dataframe.loc[current_data, column_name])
            temp_array2.append(1)
        else:
            temp_array2[temp_array.index(dataframe.loc[current_data, column_name])] += 1
        return temp_array[temp_array2.index(max(temp_array2))]
    
def data_info(dataframe):
    return dataframe.describe()

def data_correlation_columns(dataframe,column_name,column_name2):
    return dataframe[column_name].corr(dataframe[column_name2])

def data_stardard_deviation(dataframe,column_name):
    return dataframe[column_name].std()
            
def scatter_chart(dataframe,column_name,column_name1,):
    x = np.array(print_columns_value(dataframe,column_name))
    y = np.array(print_columns_value(dataframe,column_name1))
    print(x,y)
    a, b = np.polyfit(x, y, 1)
    print(a,b)
    
    plt.scatter(x, y)
    plt.plot(x, a * x + b, color='red', linestyle='-', label='Line of Best Fit')
    
    plt.xlabel(column_name)
    plt.ylabel(column_name1)
    plt.title(f'Scatter Plot of {column_name} vs {column_name1}')
    plt.legend()
    plt.savefig(os.path.join(os.path.dirname(__file__), "data.png"))
    plt.show()



print(return_dataframe_totext(df))
print(print_columns_value(df, 'Pulse'))
print( filter_by_number(df, 'Pulse', 3, 90))
print("Size of dataframe : " + str(datasize(df)))
print("Sums : " + str(sum_of_columns(df, 'Pulse')))
print("Mean : " + str(mean_of_columns(df, 'Pulse')))
print("Median : " + str(median_of_columns(df, 'Pulse')))
print("Mode : " + str(mode_of_columns(df, 'Pulse')))
print(str(data_info(df)))
print("Correlation : " + str(data_correlation_columns(df,'Pulse','Calories')))
print("Standard deviation : " + str(data_stardard_deviation(df,'Pulse')))
scatter_chart(df,'Pulse','Calories')

