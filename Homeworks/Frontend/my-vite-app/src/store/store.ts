import { configureStore } from '@reduxjs/toolkit'; // Импортируем функцию configureStore из библиотеки @reduxjs/toolkit
import counterReducerAsync from './counterSlice'; // Импортируем редьюсер из слайса
import jokeSlice from './jokeSlice';

// configureStore — это функция, которая создает хранилище
// reducer — это объект, который содержит редьюсеры
// counterReducerAsync — это редьюсер счетчика
export const store = configureStore({
    reducer: {
        counter: counterReducerAsync,
        joke: jokeSlice
    },
});

// RootState — это тип, который представляет состояние хранилища
export type RootState = ReturnType<typeof store.getState>;
// AppDispatch — это тип, который представляет функцию dispatch нашего стора
export type AppDispatch = typeof store.dispatch;