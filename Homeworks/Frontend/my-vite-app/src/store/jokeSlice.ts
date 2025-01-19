import { createSlice, PayloadAction } from '@reduxjs/toolkit'; // Импортируем функцию createSlice и тип PayloadAction из библиотеки @reduxjs/toolkit

// CounterState — это тип, который представляет состояние счетчика
interface JokeState {
    setup: string;
    punchline: string;
}

// initialState — это начальное состояние счетчика
const initialState: JokeState = {
    setup: 'Click button',
    punchline: 'and get result'
};

//Слайс — это часть хранилища, которая содержит редьюсер и действия
//createSlice — это функция, которая создает слайс
// name — это имя слайса
// initialState — это начальное состояние слайса
// reducers — это объект, который содержит редьюсеры
// increment — это редьюсер, который увеличивает значение счетчика на 1
// decrement — это редьюсер, который уменьшает значение счетчика на 1
// incrementByAmount — это редьюсер, который увеличивает значение счетчика на заданное число
// PayloadAction — это тип, который представляет действие с данными
// action.payload — это данные действия
const jokeSlice = createSlice({
    name: 'joke',
    initialState,
    reducers: {
        setSetupState: (state, action: PayloadAction<string>) => {
            state.setup = action.payload;
        },
        setPunchlineState: (state, action: PayloadAction<string>) => {
            state.punchline = action.payload;
        },
    },
});

export const { setSetupState, setPunchlineState } = jokeSlice.actions; // Экспортируем действия из слайса
export default jokeSlice.reducer; // Экспортируем редьюсер из слайса